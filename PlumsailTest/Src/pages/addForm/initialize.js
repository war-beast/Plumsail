import AddPage from "AddPage/addPage";

try {
    window.page = new AddPage();
} catch (ex) {
    console.error(ex);
}