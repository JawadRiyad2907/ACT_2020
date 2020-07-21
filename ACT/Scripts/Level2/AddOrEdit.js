$(document).ready(function () {
    FillLLevel1();
});

function FillLLevel1() {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: fillLevel1Url,
        success: function (data) {
            $.each(data, function (i, data) {
                $("#Level1Id").append('<option ' + data.selected + '  value="' + data.id + '">' + data.text + '</option>');
            });

            //selected value if variable exsist
            if (typeof SelectedLevel1 != 'undefined') {
                $('#Level1Id').val(SelectedLevel1).trigger('change');
            }
        }
    });
}