import { Controller } from "cx/ui";

import { ApiError, getAuthProviders, requestOneTimeCode, verifyOneTimeCode } from "../../api/auth";

export default class extends Controller {
    onInit() {
        this.store.set("providers", { google: false, oneTimeCode: false });

        getAuthProviders().then((providers) => this.store.set("providers", providers));

        // Google redirects back here with a reason rather than a stack trace; the query is the only
        // thing that survives the round trip.
        const error = new URLSearchParams(window.location.search).get("error");

        if (error)
            this.store.set(
                "error",
                error === "refused"
                    ? "That account is not allowed to sign in."
                    : "Signing in with Google did not work.",
            );
    }

    async onRequestCode() {
        const email = this.store.get("email") as string;

        this.store.set("busy", true);
        this.store.set("error", null);

        try {
            await requestOneTimeCode(email);
            this.store.set("codeSent", true);
        } catch (error) {
            this.store.set("error", error instanceof ApiError ? error.message : "Something went wrong.");
        } finally {
            this.store.set("busy", false);
        }
    }

    async onVerifyCode() {
        const email = this.store.get("email") as string;
        const code = this.store.get("code") as number | null;

        this.store.set("busy", true);
        this.store.set("error", null);

        try {
            // Six digits with a leading zero are still six digits; the field holds a number.
            await verifyOneTimeCode(email, String(code ?? "").padStart(6, "0"));
            window.location.href = "/";
        } catch (error) {
            this.store.set("error", error instanceof ApiError ? error.message : "Something went wrong.");
        } finally {
            this.store.set("busy", false);
        }
    }

    onStartOver() {
        this.store.set("codeSent", false);
        this.store.set("code", null);
        this.store.set("error", null);
    }
}
