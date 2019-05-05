$(function () {
    $("#datepicker").datepicker({
        dateFormat: "dd-mm-yy",
        minDate: "0d",
        maxDate: "720d",
        changeYear: true,
        changeMonth: true
    });
});