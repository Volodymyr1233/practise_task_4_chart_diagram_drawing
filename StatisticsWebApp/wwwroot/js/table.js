
document.addEventListener("DOMContentLoaded", function () {
    const table = document.getElementById("num_table");
    
    table.addEventListener("keydown", function (event) {
        if (event.target.tagName.toLowerCase() === "input" && event.key === "Enter") {
            event.preventDefault();
            const allInputs = table.querySelectorAll("input");
            const lastInput = allInputs[allInputs.length - 1];
            if (event.target === lastInput && event.target.value !== "") {
                const newInputId = allInputs.length + 1;
                const row = table.insertRow(-1);

                var cell1 = row.insertCell(0);
                var cell2 = row.insertCell(1);

                cell1.innerHTML = newInputId;

                cell2.innerHTML = `<input type="number" name="stats_numbers" id="number${newInputId}" class="form-control"/> `;
                cell2.querySelector("input").focus();
            }
        }
    });

    const img_container = document.getElementById("img-container");
    const btn_form = document.getElementById("btn-form");
    const img = new Image();
    img.src = "/images/demo.png";
    img.style = "width: 100%; height: 100%; object-fit: cover;";
    img.alt = "Demo Image";

    img.onload = function () {
        const form_button = document.createElement("button");
        form_button.type = "submit";
        form_button.className = "btn btn-primary";
        form_button.innerText = "Zapisz do bazy";
        img_container.appendChild(img);
        btn_form.appendChild(form_button);
    }

    img.onerror = function () {
        img_container.innerHTML = "<h1>Zrób swój pierwszy wykres!</h1>";
    }
});




