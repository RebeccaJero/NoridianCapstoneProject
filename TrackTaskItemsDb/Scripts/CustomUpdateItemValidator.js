(function ($) {

    $.validator.addMethod("comparequarters",
        function (value, element, params) {


            return new Date(value) > new Date($(params).val());

        });

    $.validator.addMethod("comparedates",
        function (value, element, params) {

            if ($(params).val() == null || $(params).val() == "") {
                return true;
            }
            if (params != "") {
                return new Date(value) < new Date($(params).val());
            }


        });


    $.validator.addMethod("completeddatestatus",
        function (value, element, params) {

            if (value == null || value == "") {
                return true;
            }
            if (value != "") {
                return parseInt($(params).val()) == 6;
            }


        });

    $.validator.addMethod("statuscompleted",
        function (value, element, params) {

            if ($(params).val() == "") {
                return value != "6";
            }
            if (value == "6") {
                return $(params).val() != "";
            }

        });

}(jQuery));



$(document).ready(function () {

        checkMandateandshowFields();
        showMandateFields();
        $("#StartDate").datepicker();

        $("#MandateDate").datepicker();

        $("#CompletedDate").datepicker();




        function checkMandateandshowFields() {
            var mandate = $('input:radio[name="IsMandate"]:checked').val();
            if (mandate == 'false') {
                $("#mandComment").hide();
                $("#mandDate").hide();
            }

        }

        function showMandateFields() {

            $('input:radio[name="IsMandate"]').change(
                function () {
                    if ($(this).is(':checked') && $(this).val() == 'true') {
                        $("#mandComment").show();
                        $("#mandDate").show();
                    } else {
                        $("#mandComment").hide();
                        $("#mandDate").hide();
                    }
                });
        }

    $('#editItemform').validate({ // initialize the plugin
        rules: {
            Action: {
                required: true,
                maxlength: 250
            },
            Status: {
                required: true,
                statuscompleted: CompletedDate


            },
            StartDate: {
                required: true,
                comparedates: CompletedDate


            },
            CompletedDate: {

                completeddatestatus: Status

            },
            StrategicPillarId: {
                required: true

            },
            Outcome: {
                required: true,
                maxlength: 500
            }
        },
        messages: {
            Action: {
                required: "Action is required!",
                maxlength: "250 maximum characters!"

            },
            Status: {
                required: "Status is required!",
                statuscompleted: "Please fill in the Completed Date"

            },
            StartDate: {
                required: "Start Date is required!"


            },
            CompletedDate: {

                completeddatestatus: "Status has to be Complete"

            },
            StrategicPillarId: {
                required: "Strategic Pillar is required!"

            },
         

            Outcome: {
                required: "Outcome is required!",
                maxlength: "500 maximum characters!"

            },
            MandateComment: {
                maxlength: "25 maximum characters!"
            }

        }


    })

});