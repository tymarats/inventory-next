import { Button } from "cx/widgets";

import Controller from "./Controller";

export default () => (
    <cx>
        <div class="page" controller={Controller}>
            <div class="card">
                <h1>Signed in</h1>
                <p>
                    <span text-bind="session.user.name" /> — <span text-bind="session.user.email" />
                </p>
                <p>There is nothing here yet. That is the next step.</p>
                <Button mod="primary" onClick="onSignOut" text="Sign out" style="width: 100%" />
            </div>
        </div>
    </cx>
);
