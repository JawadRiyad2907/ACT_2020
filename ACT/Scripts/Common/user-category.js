$(document).ready(function () {
    FillLLevel1();
    FillUserCategory();
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
        },
        complete: function () {
            SelectedLevel1 = undefined;
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
        },
        complete: function () {
            SelectedLevel2 = undefined;
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
        },
        complete: function () {
            SelectedLevel3 = undefined;
        }
    });


}


function FillLLevel4() {
    var Level3Id = $("#Level3Id").val();
    if (!Level3Id) {
        EmptyingLevel4();
        return;
    }
    $.ajax({
        dataType: "json",
        type: "GET",
        data: { Level3Id: Level3Id },
        url: fillLevel4Url,
        success: function (data) {
            EmptyingLevel4();
            $.each(data, function (i, data) {
                $("#Level4Id").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
            //selected value if variable exsist
            if (typeof SelectedLevel4 != 'undefined') {
                $('#Level4Id').val(SelectedLevel4).trigger('change');
            }
        },
        complete: function () {
            SelectedLevel4 = undefined;

        }
    });


}


function FillUserCategory() {
    var Level1Id = $("#Level1Id").val();
    var Level2Id = $("#Level2Id").val();
    var Level3Id = $("#Level3Id").val();
    var Level4Id = $("#Level4Id").val();
    $.ajax({
        dataType: "json",
        type: "GET",
        async: false,
        data: { Level1Id: Level1Id, Level2Id: Level2Id, Level3Id: Level3Id, Level4Id: Level4Id },
        url: fillUserCategoryUrl,
        success: function (data) {
            EmptyingUserCategory();
            $.each(data, function (i, data) {
                $("#UserCategoryId").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
            //selected value if variable exsist
            if (typeof SelectedUserCategoryId != 'undefined') {
                $('#UserCategoryId').val(SelectedUserCategoryId).trigger('change');
            }
        },
        //complete: function () {
        //    SelectedUserCategoryId = undefined;
        //}
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

function EmptyingLevel4() {
    $("#Level4Id").empty();
    $("#Level4Id").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#Level4Id').val('').trigger('change');
}

function EmptyingUserCategory() {
    $("#UserCategoryId").empty();
    $("#UserCategoryId").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#UserCategoryId').val('').trigger('change');
}


$('#Level1Id').on("change", function (e) {
    FillLLevel2();

});

$('#Level2Id').on("change", function (e) {
    FillLLevel3();

});

$('#Level3Id').on("change", function (e) {
    FillLLevel4();

});
$('#Level4Id').on("change", function (e) {
    FillUserCategory();
});