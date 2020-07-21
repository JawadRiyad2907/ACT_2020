$(document).ready(function () {
    buildTree();
});


function buildTree() {
    var $treeview = $('#privilegesTree').jstree({
        'plugins': ["wholerow", "checkbox", "types"],
        'core': {
            "themes": {
                "responsive": false
            },
            "check_callback": true,
            'data': {
                'url': menuPrivelageUrl,
                'data': function (node) {
                    return { 'id': node.id };
                }
            }
        }
    }).on('refresh.jstree', function () {
        $treeview.jstree('open_all');
    }).on('loaded.jstree', function () {
        $treeview.jstree('open_all');
    });
}


$("body").on("click", ".add-privlages", function () {
    onFormBegin();
    var privelagesIds = $("#privilegesTree").jstree("get_selected", true).map(a => a.id);
    $.ajax({
        type: "POST",
        url: savePrivelageUrl,
        data: JSON.stringify({ privelagesIds: privelagesIds }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            onFormComplete(data);
        },
    });

})