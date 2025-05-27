import { initAuth } from "./auth.js";
import { initCompare } from "./compare.js";

document.addEventListener('DOMContentLoaded', () => {
  initAuth();
  initCompare();
});