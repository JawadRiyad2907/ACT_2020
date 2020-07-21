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
        data: { Level1Id: Level1Id, Level2Id: Level2Id, Level3Id: Level3Id, Level4Id: Level4Id},
        url: fillUserCategoryUrl,
        success: function (data) {
            EmptyingUserCategory();
            $.each(data, function (i, data) {
                $("#SearchUserCategory").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
        }
    });
}
function FillJobTitle() {
    var UserCategoryId = $("#SearchUserCategory").val();
    $.ajax({
        dataType: "json",
        type: "GET",
        data: { UserCategoryId: UserCategoryId},
        url: fillJobTitleUrl,
        success: function (data) {
            EmptyingJobTitle();
            $.each(data, function (i, data) {
                $("#SearchJobTitle").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
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

function EmptyingJobTitle() {
    $("#SearchJobTitle").empty();
    $("#SearchJobTitle").append('<option value="">' + dropDownnPleaseSelect + '</option>');
    $('#SearchJobTitle').val('').trigger('change');
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

$('#SearchUserCategory').on("change", function (e) {
    FillJobTitle();
});