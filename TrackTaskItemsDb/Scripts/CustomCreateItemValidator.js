
//js task item fields validation
//validating the quarters: start quarter less thatn end Quarter

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

}(jQuery));

//js task item fields validation
$(document).ready(function () {

    $("#mandComment").hide();

    $("#mandDate").hide();

    $('#ImpactedDep').multiselect({
        includeSelectAllOption: true
    });

    $("#StartDate").datepicker();

    $("#MandateDate").datepicker();

    
    //Mandate required
    showMandateFields();

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


    $('#myform').validate({ // initialize the plugin
        rules: {
            Action: {
                required: true,
                maxlength: 250
            },
            Status: {
                required: true
                

            },
            StartDate: {
                required: true
                

            },
            
            StrategicPillarId: {
                required: true

            },
            Outcome: {
                required: true,
                maxlength: 500
            },
            EndQuarter: { comparequarters: StartQuarter },
            MandateComment: {

                maxlength: 25
            }
        },
        messages: {
            Action: {
                required: "Action is required!",
                maxlength: "250 maximum characters!"

            },
            Status: {
                required: "Status is required!"
               
            },
            StartDate: {
                required: "Start Date is required!"
                

            },
          
            StrategicPillarId: {
                required: "Strategic Pillar is required!"

            },
            EndQuarter: {
                comparequarters: "End Quarter should be greater and not equal to Start Quarter"
            },

            Outcome: {
                required: "Outcome is required!",
                maxlength: "500 maximum characters!"

            },
            MandateComment: {
                maxlength: "25 maximum characters!"
            }

        }


    });

    $("#myform").on('submit', function (e) {
        if ($("#myform").valid()) {
            e.preventDefault();
            //create task item objects
            var taskItem = {};
            var primaryDepartment = {};
            var quarterItem = {};
            var impactedDepartments = new Array();
            for (var option of document.getElementById('ImpactedDep').options) {
                if (option.selected) {
                    var impactedDep = {};
                    impactedDep.DepartmentId = option.value;
                    impactedDep.IsImpacted = true;
                    impactedDepartments.push(impactedDep);

                }
            }


            var primaryDep = $("#Department option:selected").val();
            var token = $('input[name="__RequestVerificationToken"]').val();
            primaryDepartment.DepartmentId = primaryDep;
            primaryDepartment.IsImpacted = false;
            impactedDepartments.push(primaryDepartment);

            quarterItem.StartQuarterId = $("#StartQuarter option:selected").attr("quarterId");
            quarterItem.EndQuarterId = $("#EndQuarter option:selected").attr("quarterId");
            taskItem.Outcome = $("#Outcome").val();
            taskItem.Action = $("#Action").val();
            taskItem.MandateComment = $("#MandateComment").val();
            taskItem.IsMandate = $("input:radio[name=IsMandate]:checked").val();
            taskItem.IT_Project_Number = $("#IT_Project_Number").val();
            taskItem.OperationalBudgetImplications = $("#OperationalBudgetImplications").val();
            taskItem.Department = $("#Department").val();
            taskItem.ItemDepartments = impactedDepartments;
            taskItem.Status = $("#Status").val();
            taskItem.StartDate = $("#StartDate").val();
            taskItem.MandateDate = $("#MandateDate").val();
            taskItem.StrategicPillarId = $("#StrategicPillarId").val();
            taskItem.QuarterItems = [quarterItem];

            $.ajax({
                type: "POST",
                url: "/TaskItems/CreateItem",
                contentType: 'application/x-www-form-urlencoded; charset=utf-8',
                data: {
                    __RequestVerificationToken: token,
                    taskItem: taskItem,
                },
                dataType: 'JSON',
                //data: JSON.stringify(taskItem),
                success: function (data) {
                    //alert(data);
                    window.location.href = data.redirectToUrl;
                },
                failure: function (errMsg) {
                    alert(errMsg);
                }


            });

        }
    });
});


