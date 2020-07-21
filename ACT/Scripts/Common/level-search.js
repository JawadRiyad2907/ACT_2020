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
                $("#SearchLevel1").append('<option value="' + data.id + '">' + data.text + '</option>');
            });
        }
    });
}

function FillLLevel2() {
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

function FillLLevel3() {
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

function FillLLevel4() {
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


$('#SearchLevel1').on("change", function (e) {
    FillLLevel2();
});
$('#SearchLevel2').on("change", function (e) {
    FillLLevel3();
});
$('#SearchLevel3').on("change", function (e) {
    FillLLevel4();
});


