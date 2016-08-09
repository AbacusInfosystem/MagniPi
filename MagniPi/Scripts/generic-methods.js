
function ToJavaScriptDate(value) {
    if (value != "null" && value != null && value != "") {
        var pattern = /Date\(([^)]+)\)/;
        var results = pattern.exec(value);
        var dt = new Date(parseFloat(results[1]));

        var dtDate = dt.getDate();
        if (dtDate.toString().length == 1) {
            dtDate = "0" + dtDate;
        }

        var dtMonth = dt.getMonth() + 1;
        if (dtMonth.toString().length == 1) {
            dtMonth = "0" + dtMonth;
        }

        // return (dt.getMonth() + 1) + "/" + dtDate + "/" + dt.getFullYear();
        //return dtMonth + "/" + dtDate + "/" + dt.getFullYear();
        return dtDate + "/" + dtMonth + "/" + dt.getFullYear();
    }
    else {
        return "";
    }
}