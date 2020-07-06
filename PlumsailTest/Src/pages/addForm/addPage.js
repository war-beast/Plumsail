import Vue from "Vue";
import addPageInstance from "AddPage/AddPageInstance";

export default class AddPage {
    constructor() {
        this._initializeVueInstance();
    }

    _initializeVueInstance() {
        this._addPageInstance = new Vue({
            ...addPageInstance()
        });
    }
}