$(function () {
    $(document).ready(function () {
        $('div[data-css-uvote]').each(function () {
            var value = $(this).attr('data-css-uvote')
            if (value === 1) {
                $(this).replaceWith("<li id='upVoted' width:20px height:20px></li>")
            }
        });

    });

    $(document).ready(function () {
        $('div[data-css-dvote]').each(function () {
            var value = $(this).attr('data-css-dvote')
            if (value === -1) {
                $(this).replaceWith("<li id='downVoted' width:20px height:20px></li>")
            }
        });

    });


    $(document).on("click","#up", function(){
        $(this).replaceWith("<li id='upVoted' width:20px height:20px></li>");
       
    });


    $(document).on("click", "#down", function () {
        $(this).replaceWith("<li id='downVoted' width:20px height:20px></li>");

      
    });
})

   