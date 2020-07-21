$(document).ready(function () {
    $('#FirstNameEn').on('input', function () {
        GenerateUserName();
    });
    $('#LastNameEn').on('input', function () {
        GenerateUserName();
    });
});

function GenerateUserName() {
    var FirstName = $("#FirstNameEn").val();
    var LastName = $("#LastNameEn").val();
    $.ajax({
        type: "post",
        url: generateUserNameUrl,
        data: { FirstName: FirstName, LastName: LastName, UserNameEdited: UserNameEdited },
        success: function (data) {
            $("#UserName").val(data);
            $("#Email").val(data + '@ActPrograms.net');
        }
    });
}
