import { FirstVisibleChildLayout } from "cx/ui";
import { PureContainer, RedirectRoute, Route } from "cx/widgets";

import Controller from "./Controller";
import Home from "./home";
import SignIn from "./sign-in";

// The first matching route wins, so order is the routing table: signed in or not is the outermost
// split, and everything below it can assume the answer.
export default () => (
    <cx>
        <PureContainer layout={FirstVisibleChildLayout} controller={Controller}>
            <PureContainer visible-expr="{session.status} == 'loading'">
                <div class="page">
                    <p>Loading…</p>
                </div>
            </PureContainer>

            <PureContainer layout={FirstVisibleChildLayout} if-expr="!{session.user}">
                <Route route="~/sign-in" url-bind="url" items={SignIn} />
                <RedirectRoute route="*any" url-bind="url" redirect="~/sign-in" />
            </PureContainer>

            <PureContainer layout={FirstVisibleChildLayout}>
                <Route route="~/" url-bind="url" items={Home} />
                <RedirectRoute route="*any" url-bind="url" redirect="~/" />
            </PureContainer>
        </PureContainer>
    </cx>
);
