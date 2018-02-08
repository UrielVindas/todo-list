
function isDone(id, item) {

    $.ajax({
        type: "POST",
        url: "/Home/DoneTask",
        data: '{Id: "' + id + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var newClass = item.checked ? "task-done" : "pending-task";
            $("#task" + id).removeClass().addClass(newClass);
        },
        error: function (response) {
            alert(response.msg);
        }
    });
}



