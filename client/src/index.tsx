import { Store } from "cx/data";
import { History, startHotAppLoop } from "cx/ui";

import "cx-theme-aquamarine/dist/reset.css";
import "cx-theme-aquamarine/dist/widgets.css";
import "./index.scss";

import Routes from "./routes";

const store = new Store();

History.connect(store, "url");

startHotAppLoop(module, document.getElementById("app")!, store, Routes);
