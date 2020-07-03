import Vue from "Vue";
import mainPageInstance from "MainPage/mainPageInstance";

export default class MainPage {
    constructor() {
        this._initializeVueInstance();
    }

    _initializeVueInstance() {
        this._mainPageInstance = new Vue({
            ...mainPageInstance()
        });
    }
}