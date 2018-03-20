$(document).ready(function (){

    loadGoodies();
    $('#returnChange').hide()
})

//global variables 

var moneyInSystem = 0;
var itemIdNumber = 0;

var quartersInSystem = 0;
var dimesInSystem = 0;
var nickelsInSystem = 0;
var penniesInSystem = 0;

function loadGoodies(){

    clearGoodies();

    var goodieButtons = $('#goodieSelection')

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(data, status){
            $.each(data, function (index, item){
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var goodie = '<button class="col-md-3 btn btn-default goodieButtons" id="goodieButtonId'+ id +'" onclick="getGoodie(' + id + ')">';
                    goodie += '<div class="textBox">'
                    goodie += '<p id="itemId">' + id + '</p>' + '<br/>';
                    goodie += '<h3 class="itemName">' + name + '</h3>' + '<br/>';
                    goodie += '<p>' + '$' + parseFloat(price).toFixed(2) + '</p>' + '<br/>';
                    goodie += '<p>' + 'Quantity left: ' + quantity + '</p>' + '<br/>';
                    goodie += '</div>'
                    goodie += '</button>';

                goodieButtons.append(goodie);
            });
        },
        error: function(){
            displayConnectionError()
        }
    });
}

function clearGoodies(){
    $('#goodieSelection').empty();
}

function addMoney(buttonId){    

    $("#displayChange").empty()

    if(buttonId == 1){
        moneyInSystem += 1;
        quartersInSystem += 4;
    }
    else if(buttonId == 2){
        moneyInSystem += 0.25;
        quartersInSystem += 1;
    }
    else if(buttonId == 3){
        moneyInSystem += 0.10;
        dimesInSystem += 1;
    }
    else if (buttonId == 4){
        moneyInSystem += 0.05;
        nickelsInSystem += 1;
    }

    displayMoney(moneyInSystem);
    $('#returnChange').show()
}

function getGoodie(itemId){

    $("#displayChange").empty()
    displayItem(itemId)
    itemIdNumber = itemId

    var amountToSend = parseFloat(moneyInSystem).toFixed(2)

    var urlToSend = 'http://localhost:8080/money/'
        urlToSend += amountToSend.toString()
        urlToSend += '/item/'
        urlToSend += itemId.toString()

    $.ajax({
        type: 'GET',
        url: urlToSend,
        success: function(data, status){
            var quarters = data.quarters;
            var dimes = data.dimes;
            var nickels = data.nickels;
            var pennies = data.pennies;

            quarters *= 0.25
            dimes *= 0.10
            nickels *= 0.05
            pennies *= 0.01

            var change = quarters + dimes + nickels + pennies

            displayChange(change)
            displayMessage("Thank you!")
            loadGoodies()
            resetForm()
        },
        error: function(jqXHR, status, err){
            if(err == "Unprocessable Entity"){
                // var message = jqXHR.responseText.substr(12).replace('"','').replace('}','')
                var message = jqXHR.responseJSON.message
                displayMessage(message)
            }
            else{
                displayConnectionError()
            }
        }
    })
}

$("#makePurchase").on("click", function(){
    if (itemIdNumber > 0){
        getGoodie(itemIdNumber)
    }
})

$("#returnChange").on("click", function(){

    quartersInSystem *= 0.25
    dimesInSystem *= 0.10
    nickelsInSystem *= 0.05
    penniesInSystem *= 0.01

    var change = quartersInSystem + dimesInSystem + nickelsInSystem + penniesInSystem

    displayChange(change)
    resetForm()
    $('#messageDisplay').empty()

    // var changeToReturn = moneyInSystem

    // var quarters = 0
    // var dimes = 0
    // var nickels = 0
    // var pennies = 0

    // while(changeToReturn > 0)
    // {
    //     if(changeToReturn % 0.25 == 0){
    //         changeToReturn -= 0.25
    //         quarters++
    //     }
    //     else if(changeToReturn % 0.10 == 0){
    //         changeToReturn -= 0.10
    //         dimes++
    //     }
    //     else if(changeToReturn % 0.05 == 0){
    //         changeToReturn -= 0.05
    //         nickels++
    //     }
    //     else if(changeToReturn % 0.01 == 0){
    //         changeToReturn -= 0.01
    //         pennies++
    //     }
    // }
})

function displayChange(change){
    $('#displayChange')
    .empty()
    .append($('<h4>')
    .text("$" + parseFloat(change).toFixed(2)))
}

function displayMoney(amount){
    $('#moneyDisplay')
    .empty()
    .append($('<h4>')
    .text("$" + parseFloat(moneyInSystem).toFixed(2)))
}

function displayItem(itemId){
    $('#itemDisplay')
    .empty()
    .append($('<h4>')
    .text(itemId))
}

function displayMessage(message){
    $('#messageDisplay')
    .empty()
    .append($('<h4>')
    .text(message))
}

function displayConnectionError(){
    $('#messageDisplay')
    .empty()
    .append($('<p style="color: red">')
    .text('Error calling web service. Please try again later.'));
}

function resetForm(){
    $('#moneyDisplay').empty()
    moneyInSystem = 0;

    $('#itemDisplay').empty()
    itemIdNumber = 0

    $('#returnChange').hide()

    quartersInSystem = 0
    dimesInSystem = 0
    nickelsInSystem = 0
    penniesInSystem = 0
}