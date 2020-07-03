import MainPage from "MainPage/mainPage";

try {
    window.page = new MainPage();
} catch (ex) {
    console.error(ex);
}