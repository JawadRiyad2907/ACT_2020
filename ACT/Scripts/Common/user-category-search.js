$(document).ready(function () {
    FillLevel1();
    FillUserCategory();
});


function FillLevel1() {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: fillLevel1Url,
        success: function (data) {
            $.each(data, function (i, data) {
                $("#SearchLevel1").append('<option value="' + data.id + '">' + data.text + '</option>');
            });

            if (typeof SearchSelectedLevel1 != 'undefined' && SearchSelectedLevel1) {
                $('#SearchLevel1').val(SearchSelectedLevel1).trigger('change');
            }
        },
        complete: function () {
            SearchSelectedLevel1 = undefined;
        }
    });
}

function FillLevel2() {
    var Level1Id = $("#SearchLevel1").val();
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
                $("#SearchLevel2").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
            if (typeof SearchSelectedLevel2 != 'undefined' && SearchSelectedLevel2) {
                $('#SearchLevel2').val(SearchSelectedLevel2).trigger('change');
            }
        },
        complete: function () {
            SearchSelectedLevel2 = undefined;
        }
    });


}

function FillLevel3() {
    var Level2Id = $("#SearchLevel2").val();
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
                $("#SearchLevel3").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
            if (typeof SearchSelectedLevel3 != 'undefined' && SearchSelectedLevel3) {
                $('#SearchLevel3').val(SearchSelectedLevel3).trigger('change');
            }
        },
        complete: function () {
            SearchSelectedLevel3 = undefined;
        }
    });


}

function FillLevel4() {
    var Level3Id = $("#SearchLevel3").val();
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
                $("#SearchLevel4").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
            if (typeof SearchSelectedLevel4 != 'undefined' && SearchSelectedLevel4) {
                $('#SearchLevel4').val(SearchSelectedLevel4).trigger('change');
            }
        },
        complete: function () {
            SearchSelectedLevel4 = undefined;
        }
    });


}

function FillUserCategory() {
    var Level1Id = $("#SearchLevel1").val();
    var Level2Id = $("#SearchLevel2").val();
    var Level3Id = $("#SearchLevel3").val();
    var Level4Id = $("#SearchLevel4").val();
    $.ajax({
        dataType: "json",
        type: "GET",
        async: false,
        data: { Level1Id: Level1Id, Level2Id: Level2Id, Level3Id: Level3Id, Level4Id: Level4Id },
        url: fillUserCategoryUrl,
        success: function (data) {
            EmptyingUserCategory();
            $.each(data, function (i, data) {
                $("#SearchUserCategory").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
            if (typeof SearchSelectedCategoryId != 'undefined') {

                $('#SearchUserCategory').val(SearchSelectedCategoryId).trigger('change');
            }
        },
        complete: function () {
            if (typeof SearchSelectedCategoryId != 'undefined') {
                var exists = 0 != $('#SearchUserCategory option[value=' + SearchSelectedCategoryId + ']').length;
                if (exists) {
                    SearchSelectedCategoryId = undefined;
                }
            }
        }
    });
}





function EmptyingLevel2() {
    $("#SearchLevel2").empty();
    $("#SearchLevel2").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchLevel2').val('').trigger('change');
}
function EmptyingLevel3() {
    $("#SearchLevel3").empty();
    $("#SearchLevel3").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchLevel3').val('').trigger('change');
}

function EmptyingLevel4() {
    $("#SearchLevel4").empty();
    $("#SearchLevel4").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchLevel4').val('').trigger('change');
}
function EmptyingUserCategory() {
    $("#SearchUserCategory").empty();
    $("#SearchUserCategory").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchUserCategory').val('').trigger('change');
}

$('#SearchLevel1').on("change", function (e) {
    FillLevel2();
});
$('#SearchLevel2').on("change", function (e) {
    FillLevel3();
});
$('#SearchLevel3').on("change", function (e) {
    FillLevel4();
});
$('#SearchLevel4').on("change", function (e) {
    FillUserCategory();
});

