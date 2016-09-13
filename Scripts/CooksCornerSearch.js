$ (function() 
{

    var AjaxFormSubmit = function ()
    {
        var $form = $(this)

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data){
            var $target = $($form.attr("data-ccs-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
            $newHtml.effect("fadein");
        });
        return false;
    }
    $("form[data-CCS-Ajax=true]").submit(AjaxFormSubmit);
})

