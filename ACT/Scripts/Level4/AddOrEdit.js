$(document).ready(function () {
    FillLLevel1();
    FillTypeEducation();
    FillSchoolType();
    IsOtherEducationFlag();
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



function FillLLevel3() {
    var Level2Id = $("#Level2Id").val();
    if (!Level2Id) {
        EmptyingLevel3();
        return;
    }
    $.ajax({
        dataType: "json",
        type: "GET",
        data: { Level2Id: Level2Id },
        url: fillLevel3Url,
        success: function (data) {
            EmptyingLevel3();
            $.each(data, function (i, data) {
                $("#Level3Id").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
            //selected value if variable exsist
            if (typeof SelectedLevel3 != 'undefined') {
                $('#Level3Id').val(SelectedLevel3).trigger('change');
            }
        }
    });


}


function FillTypeEducation() {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: fillTypeEducationUrl,
        success: function (data) {
            $.each(data, function (i, data) {
                $("#TypeEducationId").append('<option ' + data.selected + '  value="' + data.id + '">' + data.text + '</option>');
            });

            //selected value if variable exsist
            if (typeof SelectedTypeEducationId != 'undefined') {
                $('#TypeEducationId').val(SelectedTypeEducationId).trigger('change');
            }
        }
    });
}


function FillSchoolType() {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: fillSchoolTypeUrl,
        success: function (data) {
            $.each(data, function (i, data) {
                $("#TypeId").append('<option ' + data.selected + '  value="' + data.id + '">' + data.text + '</option>');
            });

            //selected value if variable exsist
            if (typeof SelectedTypeEducationId != 'undefined') {
                $('#TypeId').val(SelectedTypeEducationId).trigger('change');
            }
        }
    });
}




function EmptyingLevel2() {
    $("#Level2Id").empty();
    $("#Level2Id").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#Level2Id').val('').trigger('change');
}


function EmptyingLevel3() {
    $("#Level3Id").empty();
    $("#Level3Id").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#Level3Id').val('').trigger('change');
}



$('#Level1Id').on("change", function (e) {
    FillLLevel2();
});

$('#Level2Id').on("change", function (e) {
    FillLLevel3();
});


$('#IsOtherEducation').change(function () {
    IsOtherEducationFlag();
});



function IsOtherEducationFlag() {
    if ($('#IsOtherEducation').is(':checked')) {
        $(".other-education-row").show();
    }
    else {
        $(".other-education-row").hide();
        $("#OtherEducationName").val('');
    }
}