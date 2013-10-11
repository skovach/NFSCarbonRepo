﻿
$(function() {


    var ajaxFormSubmit = function() {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function(data) {
            var $target = $($form.attr("data-nfs-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight", {color: 'black'}, 500);
        });
        
        return false;
    };

    var submitAutocompleteForm = function(event, ui) {
        
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutocomplete = function() {
        var $input = $(this);

        var options = {
            source: $input.attr("data-nfs-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    };


    var getPage = function() {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function(data) {
            var target = $a.parents("div.pagedList").attr("data-nfs-target");
            $(target).replaceWith(data);
        });
        return false;
    };

    $("form[data-nfs-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-nfs-autocomplete]").each(createAutocomplete);

    $(".main-content").on("click", ".pagedList a", getPage);

});