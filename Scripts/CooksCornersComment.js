$(function () {

    $('#commentform').submit(function(){
        var $form = $(this)

        var $data = {
            RecipeId: $('#RecipeId').val(),
            comment: $('#comment').val(),
            
        };
                    

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $data,
            sucess: function (result) {
                document.location.reload()
                 
                
            },
            error: function (result) {
                alert("We were unable to post your comment");
            },
            complete:function()
            {
                document.location.reload();
            }
        });
    return false;
});
});
   

 