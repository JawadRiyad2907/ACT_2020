$(document).ready(function () {
    Metronic.init(); // init metronic core components
    Layout.init(); // init current layout
    QuickSidebar.init(); // init quick sidebar
    /*Demo.init();*/ // init demo features
    InitTouchspin();
    //InitToastr();
    InitDatePicker();
});



function InitDatePicker() {
    $('.date-picker').datepicker({
        rtl: Metronic.isRTL(),
        orientation: "left",
        autoclose: true,
        format: 'dd/mm/yyyy',
       
    });
}




function InitTouchspin() {
    $(".touchspin_number").TouchSpin({
        buttondown_class: 'btn defualt',
        buttonup_class: 'btn defualt',
        min: 0,
        max: 1000000000,
        stepinterval: 50,
        maxboostedstep: 10000000
    });
}

function loadingButton(btn) {

    var $this = btn;
    var btnText = $this.html();
    $this.prop('disabled', true);
    var loadingText = " <span class='fa fa-spinner fa-spin'></span> ";
    $this.append(loadingText);
    //if ($this.html() !== loadingText) {
    //    //$this.html(loadingText);
    //}
}
function removeLoadingButton(btn) {
    debugger;
    var $this = btn;
    $this.prop('disabled', false);
    $this.children('span').remove();
}
function onFormBegin() {
    loadingButton($('input[type="submit"],button[type="submit"],.submit'));
}

function showConfim(title,text,confirmText,closeText)
{

    swal({
        title: title,
        text: text,
        icon: "warning",
        buttons: true,
        dangerMode: true,
        buttons: [closeText, confirmText],
    })
        .then((yes) => {
        if (yes) {
            return true;
        } else {
            return false;
            }
        });
}
function showFailDialog(title, text, closeText) {
    var stringTohtml = document.createElement("div");
    stringTohtml.innerHTML = text;
    swal({
        title: title,
        content: stringTohtml,
        icon: "error",
        html: true,
        buttons: {
            close: {
                text: closeText
            }
        }
    });
    removeLoadingButton($('input[type="submit"],button[type="submit"],.submit'));
}
function onFormComplete(data) {
    removeLoadingButton($('input[type="submit"]>.fa-spinner,button[type="submit"]>.fa-spinner'));
    removeLoadingButton($(".submit"));
    if (data.success === true)
    {
        showResultDialog(successTitle, successText, successOkButton, returnUrl);
        return;
    }
    if (data.responseJSON !== undefined || data.result === true || data === true) {
        if (data.responseJSON && data.responseJSON.success === true) {
            if (data.responseJSON.refNo) {
                successText = data.responseJSON.refNo;
            }

            showResultDialog(successTitle, successText, successOkButton, returnUrl);

            $(this).closest('form').find("input[type=text], textarea").val("");
            $(this).closest('form').find("select").val("");
        }
        else {
            if (data.responseJSON.ErrorsList) {
                unsuccessText = data.responseJSON.ErrorsList.join(" \r\n ");
            }

            showFailDialog(unsuccessTitle, unsuccessText, unsuccessOkButton);
        }
    } else {
        //error page
        showFailDialog(unsuccessTitle, data.responseText, unsuccessOkButton);
    }
}

function showResultDialog(title, text, closeText, returnUrl) {
    swal({
        title: title,
        icon: "success",
        html: text,
        buttons: {
            close: {
                text: closeText
            }
        }
    }).then((value) => {
        window.location.href = returnUrl;
    });
}

// cancel button function
function cancel() {
    var cancelPage = returnUrl.trim();
    window.open(cancelPage, "_self");
}

$('body').on('click', '.cancel-button', function () {
    cancel();
});

function OperationError() {
    showFailDialog(unsuccessTitle, unsuccessText, unsuccessOkButton);
}


function onDeleteComplete(data) {
    debugger;
    if (data && data.success === true) {
        showDeleteSuccess(successDelete, '', successOkButton);
    } else if (data && data.success === false) {
        var unsuccessText = data.ErrorsList;
        showFailDialog(unsuccessDelete, unsuccessText, unsuccessOkButton);
    }
    else {
        showFailDialog(unsuccessDelete, data, unsuccessOkButton);
    }
}
function showDeleteSuccess(title, text, closeText) {
    swal({
        title: title,
        icon: "success",
        html: text,
        buttons: {
            close: {
                text: closeText
            }
        }
    });
}
// common functions
function isNullOrUndefined(obj) {
    return typeof obj === "undefined" || obj === null;
}
function isNullOrWhiteSpace(str) {
    if (isNullOrUndefined(str))
        return true;
    if (typeof (str) !== 'string')
        return true;
    if (str.length == 0)
        return true;
    return false;
}

$('.prevent-paste').on("paste", function (e) {
    e.preventDefault();
});

//attachments
$("#add-attachment").click(function () {
    var templ = $("#attachmentTemplate").tmpl();
    templ.attr('style', 'display:none;');
    templ.appendTo("#attachment-template-container");
    templ.show('fast', function () {
        renameFileInputs();
    });
});
$("#delete-attachment").click(function () {
    var element = $(this);
    loadingButton(element);
    var fieldId = this.dataset["fieldid"];
    $.ajax({
        url: baseUrl + "/Attachment/DeleteAttachment",
        type: 'post',
        data: { fileId: fieldId },
        dataType: 'json',
        success: function (response) {
            if (response.success) {
                successNotification(successTitle, successOkButton);
                window.location.reload();
            }
            removeLoadingButton(element);

        },
        fail: function () {
            failNotificatiaon(unsuccessTitle, unsuccessOkButton);
            removeLoadingButton(element);
        }
    });
});
function showAttachmentDeleteButton() {
    $(".del-att").show();
}
var renameFileInputs = function () {
    var index = 0;
    $("#attachment-template-container .filebase").each(function (e) {
        $(this).closest(".row").find(".filename").attr("name", "Attachments[" + index + "].FileDescription");
        $(this).attr("name", "Attachments[" + index + "].File");
        $('input[name="Attachments[' + index + '].File"]').uniform({
            fileButtonHtml: "اختر ملف"
        });
        index++;
    });
};
var removeFile = function (element) {
    var element = $(element).closest(".row");
    element.hide('fast', function () {
        element.remove();
        renameFileInputs();
        handleSingleFileSelect();
    });
}
function handleSingleFileSelect(element) {

    let totalSize = 0;
    $("input[type='file'].filebase").each(function () {
        var file = this.files[0];
        if (typeof (file) !== 'undefined') {
            totalSize += parseInt(file.size);
        }
    });
    var fileSizeTotalProp = $("#TotalFileSize")[0];
    if (typeof (fileSizeTotalProp) !== 'undefined') {
        $("#TotalFileSize + span.size").remove();
        fileSizeTotalProp.value = totalSize;
        $('<span class="size"> ( ' + bytesToSize(totalSize) + ' ) </span>').insertAfter(fileSizeTotalProp)
        //raise change event 
        $(fileSizeTotalProp).change();
        $(fileSizeTotalProp).blur();
    }

    if (typeof (element) === 'undefined')
        return {}
    var file = element.files[0];
    if (typeof (file) === 'undefined')
        return {}

    return {
        fileName: file.name,
        fileType: file.type,
        fileLastModifiedDate: file.lastModifiedDate ? file.lastModifiedDate.toLocaleDateString() : 'n/a',
    }
}
function bytesToSize(bytes) {
    var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
    if (bytes == 0) return '0 Byte';
    var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
    return Math.round(bytes / Math.pow(1024, i), 2) + ' ' + sizes[i];
}
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

