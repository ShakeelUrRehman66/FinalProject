$(document).ready(function () {
    $(".Delete").click(function (e) {
        e.preventDefault();
        var item = $(".Delete").attr("href");
        var separator = item.split("/");
        var id = separator[3];
        console.log(id);
        alert("Are You Sure TO Delete This")

        $.ajax({
            url: item,
            Type: "Post",

            success: function (result) {
                var item = document.getElementById(id);
                item.remove();

            }

        });


    });
});