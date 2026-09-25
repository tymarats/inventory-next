import { Controller } from "cx/ui";

import { getCurrentUser } from "../api/auth";

/**
 * The session is resolved once, at the root, because every route below depends on the answer. Until
 * it arrives the app shows neither the sign-in screen nor the application, which is what stops a
 * signed-in person seeing a sign-in form for a moment on every load.
 */
export default class extends Controller {
    onInit() {
        this.store.set("session.status", "loading");

        getCurrentUser()
            .catch(() => null)
            .then((user) => this.store.set("session", { status: "ok", user }));
    }
}
