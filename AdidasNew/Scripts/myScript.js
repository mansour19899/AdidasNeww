$(document).ready(function () {

    var _my_height = $(window).height();
    var _my_bootom = $(window).width()/2-100;
    $("._Header").css("height", _my_height);
    $("#hi").css("right", _my_bootom);

    // کلاس دکمه
    $("#hi").click(function () {
        $("._Header").fadeOut(1500);
        $(".allcontentpage").fadeIn(1500);
    });

    $(window).resize(function () {
        var _my_height = $(window).height();
        var _my_bootom = $(window).width() / 2 - 100;
        $("._Header").css("height", _my_height);
        $("#hi").css("right", _my_bootom);
    });

    $("#Person_Gender").change(function () {

    

        if ($(this).val() != "true") {
            $("#Person_MilitaryService").val(0);
            $("#Person_MilitaryService").attr("disabled", "disabled");

        }
        else {
            $("#Person_MilitaryService").removeAttr("disabled");
        }

    })

    $("#Person_Marriage").change(function () {

     

        if ($(this).val() == "true") {
            $("#Person_Children").val (0);
            $("#Person_Children").attr("disabled", "disabled");

        }
        else {
            $("#Person_Children").removeAttr("disabled");
        }

    })


    $("#Person_JobStatus").change(function () {



        if ($(this).val() == "true") {
            $("#Person_DaysNumber").val(0);
            $("#Person_DaysNumber").attr("disabled", "disabled");

        }
        else {
            $("#Person_DaysNumber").removeAttr("disabled");
        }

    })

    $("#Person_WorkingGuranty").change(function () {



        if ($(this).val() == "true") {
            $("#Person_Duration").val(0);
            $("#Person_Duration").attr("disabled", "disabled");

        }
        else {
            $("#Person_Duration").removeAttr("disabled");
        }

    })

    $("#Person_SalaryExpection").keyup(function () {

        var number = typeof $(this).val() === "number" ? $(this).val().toString() : $(this).val();
        numberr = number.replace(',', '');
        var numberrr = numberr.replace(',', '');
        var numberrrr = numberrr.replace(',', '');
        var numberrrrr = numberrrr.replace(',', '');
        var numberrrrrr = numberrrrr.replace(',', '');
        var numberrrrrrr = numberrrrrr.replace(',', '');

        
        $(this).val(numberrrrrrr.replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1" + ','));

      

      
    })

    $("#RelationShip1_Moaref").change(function () {

       

        if ($(this).val() == "true") {
            $("#moaref").text("معرف");
            

        }
        else {
            $("#moaref").text("ردیف 1");
        }

    })

});