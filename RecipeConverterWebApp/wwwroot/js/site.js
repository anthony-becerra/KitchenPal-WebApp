// Write your JavaScript code.
'use strict';


$(document).ready(function () {


    const Rform = $('#recipe_form'); // get the form with id "recipe_form"
    let i = 1;

    Rform.find("button#AddIngredient").click(function (e) {
        e.preventDefault(); // overrides function of the button. Prevents its default function of element.

        const ingFields = Rform.find("#ingredients_list #ing_0").html();
        let newIngFields = ingFields.replace(/_0/g, `_${i}`);
        Rform.find('#ingredients_list').append(`<div class="ingredient" id="ing_${i}">${newIngFields}</div>`);

        i++;

        // console.log(ingFields); // verification
        // console.log(newIngFields); // verification

    });

    Rform.submit(function (e) {
        e.preventDefault(); // Wouldn't need this in my case since I want the page to refresh

        let newRecipe = new Object();

        newRecipe.name = Rform.find("#recipe_name").val();
        newRecipe.desc = Rform.find("#recipe_desc").val();
        newRecipe.origin_ss = Rform.find("#origin_ss").val();
        newRecipe.desired_ss = Rform.find("#desired_ss").val();
        newRecipe.ingredients = {};

        let x = 0;
        // Search form for ingredient class and for each of them do something
        Rform.find('.ingredient').each(function () {
            //console.log(this.id); //verification
            newRecipe.ingredients[this.id] = {};
            let ing_c = newRecipe.ingredients[this.id];
            let ing_div = Rform.find(`.ingredient#${this.id}`);

            ing_c.ingredient = ing_div.find(`#ing_${x}`).val();
            ing_c.measurement = ing_div.find(`#meas_${x}`).val();
            ing_c.quantity = ing_div.find(`#qty_${x}`).val();

            x++;
        });

        // Send above object to controller action
        $.ajax({
            url: "/Form/AddForm",
            type: "POST",
            data: newRecipe,
            // 
            success: function (result) {
                console.log(result);

                $('#recipe_result').html(`
                    
                    <h1>Recipe Name: ${result.name}</h1>
                    <h3>Recipe Description: ${result.desc}</h3>
                    <hr class="divider">
                    <h4>Original Serving Size: ${result.origin_ss} | Desired Serving Size: ${result.desired_ss}</h4>
                    <hr class="divider">
                    <ul>
                `);

                //let i = 1;

                for (let ing in result.ingredients) {
                    let detail = result.ingredients[ing];
                    
                    $('#recipe_result').append(`<li>${parseFloat(detail.quantity).toFixed(2)} ${detail.measurement} ${detail.ingredient}</li>`);
                };

                $('#recipe_result').append(`</ul>`);
                
            }
        });
    });

    
    // console.log(newRecipe); // verification


})