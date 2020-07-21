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




function FillLLevel2() {
    var Level1Id = $("#Level1Id").val();
    if (!Level1Id) {
        EmptyingLevel2();
        return;
    }
    $.ajax({
        dataType: "json",
        type: "GET",
        data: { Level1Id: Level1Id },
        url: fillLevel2Url,
        success: function (data) {
            EmptyingLevel2();
            $.each(data, function (i, data) {
                $("#Level2Id").append('<option value="' + data.id + '">' + data.text + '</option>');
            });


            //selected value if variable exsist
            if (typeof SelectedLevel2 != 'undefined') {
                $('#Level2Id').val(SelectedLevel2).trigger('change');
            }
        }
    });


}

function EmptyingLevel2() {
    $("#Level2Id").empty();
    $("#Level2Id").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#Level2Id').val('').trigger('change');
}


$('#Level1Id').on("change", function (e) {
    FillLLevel2();
});