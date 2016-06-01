﻿// Functions with automatic initialization
$(function ($) {
    // Loading datatable to fiscal years.
    $("#table-fiscalyears").DataTable({
        "sAjaxSource": "/FiscalYear/ListAllFiscalYears",
        "columnDefs": [
            {
                "width": "10%", "targets": 2,
                "orderable": false
            }
        ]
    });

    // Send the new account request to specific controller/action in Arda.Main.
    $("#loginform").submit(function (e) {
        e.preventDefault();

        $("#email").attr("disabled", "disabled");
        $("#password").attr("disabled", "disabled");
        $("#signin").attr("disabled", "disabled");

        $("#signin").text("Validating user data...");

        var email = $("#email").val();
        var password = $("#password").val();

        $.ajax({
            url: "http://localhost:2787/api/authentication/userauthentication",
            type: "POST",
            data: { Email: email, Password: password },
            dataType: "json"
        }).done(function (data) {
            if (data.Status == "Ok") {
                ClearModalForm();
                RedirectTo("http://localhost:2168/Dashboard/Index");
            }
            else if (data.Status == "Inactive")
            {
                $("#MessagePanelLogin").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> The requested user is here but is inactive. Please, consult the system admin.</div>");
                $("#signin").html("Sign in");
                ClearModalForm();
                $("#email").removeAttr("disabled");
                $("#password").removeAttr("disabled");
                $("#signin").removeAttr("disabled");
                
            }
            else
            {
                $("#MessagePanelLogin").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Ops!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
                $("#signin").html("Sign in");
                ClearModalForm();
                $("#email").removeAttr("disabled");
                $("#password").removeAttr("disabled");
                $("#signin").removeAttr("disabled");
            }
        }).fail(function (e, f) {
            $("#MessagePanelLogin").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Ops!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
            $("#signin").html("Sign in");
            ClearModalForm();
            $("#email").removeAttr("disabled");
            $("#password").removeAttr("disabled");
            $("#signin").removeAttr("disabled");
        });

    });

    // Send the new account request to specific controller/action in Arda.Main.
    $("#NewAccountRequest").submit(function (e) {
        e.preventDefault();

        $("#RequestAccountButton").attr("disabled", "disabled");
        $("#RequestAccountButton").text("Requesting...");

        var pName = $("#Name").val();
        var pEmail = $("#Email").val();
        var pPhone = $("#Phone").val();
        var pJustification = $("#Justification").val();

        $.ajax({
            url: "http://localhost:2787/api/accountoperations/requestnewaccount",
            type: "POST",
            data: { Name: pName, Email: pEmail, Phone: pPhone, Justification: pJustification },
            dataType: "json"
        }).done(function (data) {
            if (data.Status == "Ok") {
                $("#MessagePanel").html("<div class='alert alert-success'><strong>Success!</strong> Your request was sent. Thank you.</div>");
                $("#RequestAccountButton").removeAttr("disabled");
                $("#RequestAccountButton").html("<span class='glyphicon glyphicon-ok'></span>&nbsp;Request account");
                ClearModalForm();
            }
        }).fail(function (e, f) {
            $("#MessagePanel").html("<div class='alert alert-danger'><strong>Error!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
            $("#RequestAccountButton").html("<span class='glyphicon glyphicon-ok'></span>&nbsp;Request account");
        });
    
    });

    // Send the help request to specific controller/action in Arda.Main.
    $("#RadioGroup").submit(function (e) {
        e.preventDefault();

        $("#SendHelpRequest").attr("disabled", "disabled");
        $("#SendHelpRequest").text("Requesting...");

        var Value;

        if ($("input[name='radiooption']:checked").val() == "1") {
            Value = $("#YourCompleteName").val();
        }
        else if($("input[name='radiooption']:checked").val() == "2") {
            Value = $("#YourEmail").val();
        }
        else {
            Value = $("#YourDescription").val();
        }

        // Sending the help request
        $.ajax({
            url: "http://localhost:2787/api/accountoperations/requesthelp",
            type: "POST",
            data: { RequestType: Value },
            dataType: "json"
        }).done(function (data) {
            if (data.Status == "Ok") {
                $("#MessagePanel").html("<div class='alert alert-success'><strong>Success!</strong> Your help request was sent. Thank you.</div>");
                $("#SendHelpRequest").removeAttr("disabled");
                $("#SendHelpRequest").html("<span class='glyphicon glyphicon-ok'></span>&nbsp;Send help request");
                ClearModalForm();
            }
            else {
                $("#MessagePanel").html("<div class='alert alert-danger'><strong>Error!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
                $("#SendHelpRequest").removeAttr("disabled");
                $("#SendHelpRequest").html("<span class='glyphicon glyphicon-ok'></span>&nbsp;Send help request");
            }
        }).fail(function () {
            $("#MessagePanel").html("<div class='alert alert-danger'><strong>Error!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
            $("#RequestAccountButton").html("<span class='glyphicon glyphicon-ok'></span>&nbsp;Send help request");
        });
    });

    $("#form-edit-fiscal-year").validate({
        rules: {
            FiscalYearID: "required",
            TextualFiscalYearMain: "required",
            FullNumericFiscalYearMain: "required"
        },
        messages: {
            FiscalYearID: "Please, inform the fiscal year code.",
            TextualFiscalYearMain: "Please, type the textual form of fiscal year.",
            FullNumericFiscalYearMain: "Please, inform the numeric form of fiscal year."
        },
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        submitHandler: function (form) {
            DisableFiscalYearFields();
            $("#btnUpdate").text("Updating fiscal year data...");

            $.ajax({
                url: "/FiscalYear/EditFiscalYear",
                type: "POST",
                data: $(form).serialize()
            }).done(function (data) {
                if (data.Status == "Ok") {
                    ClearModalForm();
                    $("#message").html("<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Success!</strong> The fiscal year was updated succefully.</div>");
                    $("#btnUpdate").html("<i class='fa fa-floppy-o' aria-hidden='true'></i> Save");
                    EnableFiscalYearFields();
                    RedirectIn(3000, "/FiscalYear/Index");
                }
                else {
                    $("#message").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Ops!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
                    $("#btnUpdate").html("<i class='fa fa-floppy-o' aria-hidden='true'></i> Save");
                    EnableFiscalYearFields();
                }
            }).fail(function (e, f) {
                $("#message").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Ops!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
                $("#btnUpdate").html("<i class='fa fa-floppy-o' aria-hidden='true'></i> Save");
                EnableFiscalYearFields();
            });
        }

    });

    $("#form-add-fiscal-year").validate({
        rules: {
            FiscalYearID: "required",
            TextualFiscalYearMain: "required",
            FullNumericFiscalYearMain: "required"
        },
        messages: {
            FiscalYearID: "Please, inform the fiscal year code.",
            TextualFiscalYearMain: "Please, type the textual form of fiscal year.",
            FullNumericFiscalYearMain: "Please, inform the numeric form of fiscal year."
        },
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        submitHandler: function (form) {
            DisableFiscalYearFields();
            $("#btnAdd").text("Saving the new fiscal year...");

            $.ajax({
                url: "/FiscalYear/AddFiscalYear",
                type: "POST",
                data: $(form).serialize()
            }).done(function (data) {
                if (data.Status == "Ok") {
                    ClearModalForm();
                    $("#message").html("<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Success!</strong> Fiscal year has been added into Arda.</div>");
                    $("#btnAdd").html("<i class='fa fa-floppy-o' aria-hidden='true'></i> Save");
                    EnableFiscalYearFields();

                    RedirectIn(3000, "/FiscalYear/Index");
                }
                else {
                    $("#message").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
                    $("#btnAdd").html("<i class='fa fa-floppy-o' aria-hidden='true'></i> Save");
                    EnableFiscalYearFields();
                }
            }).fail(function (e, f) {
                $("#message").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> Something wrong happened with your request. Try again in few minutes.</div>");
                $("#btnAdd").html("<i class='fa fa-floppy-o' aria-hidden='true'></i> Save");
                $("#btnAdd").html("<i class='fa fa-floppy-o' aria-hidden='true'></i> Save");
                EnableFiscalYearFields();
            });
        }
    });
});

// General functions


// Modais

function MountNeedHelpModal() {
    //Defining values
    var ModalTitle = "How can we help?";
    var ModalBody = "<p style='margin-bottom:20px;' class='p-modal-body'>What's happening? Please, select the best option below.</p>";
    ModalBody += "<p class='p-modal-body'>";
    ModalBody += "<div>";
    ModalBody += "<div class='radio'>";
    ModalBody += "<label><input type='radio' name='radiooption' id='RadioEmail' value='1' onchange='CheckRadio();'>I'm having problems with my email (manual process)</label>";
    ModalBody += "</div>";
    ModalBody += "<div id='YourCompleteNameField'></div>"
    ModalBody += "<div class='radio'>";
    ModalBody += "<label><input type='radio' name='radiooption' id='RadioPassword' value='2' onchange='CheckRadio();'>I'm having problems with my password (automatic process)</label>";
    ModalBody += "</div>";
    ModalBody += "<div id='YourEmailField'></div>"
    ModalBody += "<div class='radio'>";
    ModalBody += "<label><input type='radio' name='radiooption' id='RadioAnother' value='3' onchange='CheckRadio();'>I'm having another kind of problem (manual process)</label>";
    ModalBody += "</div>";
    ModalBody += "<div id='DescriptionField'></div>"
    ModalBody += "</p>";
    ModalBody += "</div>";
    ModalBody += "<div id='MessagePanel'></div>";
    
    //Injecting contents
    $("#GenericModal2 .modal-title").html("<strong>" + ModalTitle + "</strong>");
    $("#GenericModal2 .modal-body").html("<strong>" + ModalBody + "</strong>");
    $("#GenericModal2 .modal-footer").html("<button type='submit' class='btn btn-success' id='SendHelpRequest' disabled='disabled'><span class='glyphicon glyphicon-ok'></span>&nbsp;Send help request</button>");
}

function MountRequestNewAccountModal() {
    var ModalTitle = "Request a new account";
    var ModalBody = "<p style='margin-bottom:20px;' class='p-modal-body'>In order to get a new system account please, fill all requested informations at form below and click in 'Request account'.</p>";
    
    ModalBody += "<p>";
            ModalBody += "<fieldset class='form-group'>";
            ModalBody += "<label for='Name'>Name</label>";
            ModalBody += "<input type='text' class='form-control' id='Name' placeholder='Your complete name' required>";
            ModalBody += "</fieldset>";
            ModalBody += "<fieldset class='form-group'>";
            ModalBody += "<label for='Email'>Email</label>";
            ModalBody += "<input type='email' class='form-control' id='Email' placeholder='alias@yourdomain.com' required>";
            ModalBody += "</fieldset>";
            ModalBody += "<fieldset class='form-group'>";
            ModalBody += "<label for='Phone'>Phone</label>";
            ModalBody += "<input type='tel' class='form-control' id='Phone' placeholder='(11) 01234-5678'>";
            ModalBody += "</fieldset>";
            ModalBody += "<fieldset class='form-group'>";
            ModalBody += "<label for='Justification'>Justification</label>";
            ModalBody += "<textarea class='form-control' id='Justification' placeholder='Tell us: why you need this account?' required></textarea>";
            ModalBody += "</fieldset>";
     ModalBody += "</p>";
     ModalBody += "<div id='MessagePanel'></div>";
    
    //Injecting contents
    $("#GenericModal .modal-title").html("<strong>" + ModalTitle + "</strong>");
    $("#GenericModal .modal-body").html(ModalBody);
    $("#GenericModal .modal-footer").html("<button type='submit' class='btn btn-success' id='RequestAccountButton'><span class='glyphicon glyphicon-ok'></span>&nbsp;Request account</button>");
}

function ModalDelete_FiscalYear(FiscalYearID, TextualFiscalYear) {
    //Defining values
    var ModalTitle = "Deleting '" + TextualFiscalYear + "' record";
    var ModalBody = "<p style='margin-bottom:20px; font-weight: 400;' class='p-modal-body'>This operation will be permanent. Are you sure?</p>";
    ModalBody += "<p><ul>";
    ModalBody += "<li>Fiscal year ID: " + FiscalYearID + "</li>";
    ModalBody += "<li>Fiscal year (textual mode): " + TextualFiscalYear + "</li>";
    ModalBody += "</ul></p>";
    ModalBody += "<div id='message-panel' style='margin-top: 10px;'></div>"
    
    //Injecting contents
    $("#generic-modal .modal-title").html("<strong>" + ModalTitle + "</strong>");
    $("#generic-modal .modal-body").html(ModalBody);
    $("#generic-modal .modal-footer").html("<button type='button' class='btn btn-danger' id='btnDelete' onclick=\"DeleteFiscalYear('" + FiscalYearID + "');\"><i class='fa fa-trash' aria-hidden='true'></span>&nbsp;Delete</button>");
}


// Another functions

function ClearModalForm() {
    $("form").trigger("reset");
}

function CheckRadio() {
    $("#SendHelpRequest").removeAttr("disabled");

    if ($("input[name='radiooption']:checked").val() == "1") {
        $("#YourCompleteNameField").html("<fieldset class='form-group'><input type='text' class='form-control' id='YourCompleteName' placeholder='Your complete name here' required></fieldset>");
        $("#YourEmailField").html("");
        $("#DescriptionField").html("");
    }
    else if ($("input[name='radiooption']:checked").val() == "2") {
        $("#YourEmailField").html("<fieldset class='form-group'><input type='text' class='form-control' id='YourEmail' placeholder='Your email here' required></fieldset>");
        $("#YourCompleteNameField").html("");
        $("#DescriptionField").html("");
    }
    else {
        $("#DescriptionField").html("<fieldset class='form-group'><textarea class='form-control' id='YourDescription' placeholder='Describes your problem here' required></textarea></fieldset>");
        $("#YourCompleteNameField").html("");
        $("#YourEmailField").html("");
    }
}

function RedirectTo(url)
{
    window.location = url;
}

function DisableFiscalYearFields()
{
    $("#fyid").attr("disabled", "disabled");
    $("#fytext").attr("disabled", "disabled");
    $("#fynumber").attr("disabled", "disabled");
    $("#btnUpdate").attr("disabled", "disabled");
}

function EnableFiscalYearFields()
{
    $("#fyid").removeAttr("disabled");
    $("#fytext").removeAttr("disabled");
    $("#fynumber").removeAttr("disabled");
    $("#btnUpdate").removeAttr("disabled", "disabled");
}

function RedirectIn(delay, url)
{
    setTimeout(function () {
        window.location = url;
    }, delay);
}

function DeleteFiscalYear(fiscalYearID) {
    $("#btnDelete").attr("disabled", "disabled");

    $.ajax({
        url: "/FiscalYear/Delete",
        type: "POST",
        data: { id: fiscalYearID },
        success: function (data) {
            if (data.Status) {
                $("#message-panel").html("<div class='alert alert-success'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Success!</strong> Fiscal year successful deleted.</div>");
                RedirectIn(4000, "/FiscalYear/Index");
            } else {
                $("#message-panel").html("<div class='alert alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> We found an error in this request. Try again in a few minutes.</div>");
            }
        }
    });
}
