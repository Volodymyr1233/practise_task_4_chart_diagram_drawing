
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
});




