document.addEventListener("DOMContentLoaded", init);

const time = 1000;

function init() {
    const sortContainers = document.getElementsByClassName("sort-container");

    for (let container of sortContainers) {
        console.log(container);
        let n = parseInt(container.getAttribute("value"));

        for (let i = 0; i < n; i++) {
            const bar = document.createElement("div");
            const text = document.createElement("span");
            bar.classList.add("bar");
            bar.style.order = i;
            const value = n - i;
            bar.value = value;
            bar.style.height = `${value/n*90+10}%`;
            //text.textContent = value;
            bar.appendChild(text);
            container.appendChild(bar)
        }
        shuffle(container);
        sort(container);
    }
}

function shuffle(container) {
    let arr = Array.from(container.children).sort((a, b) => parseInt(a.style.order) - parseInt(b.style.order));
    for (let i = 0; i < arr.length; i++) {
        swap(arr, i, Math.floor(Math.random() * (arr.length - 1)));
    }
}

function sort(container) {
    let index = 0;
    let swapped = false;
    let sorted = 1;
    let delay = time / parseInt(container.getAttribute("value"));
    let sortTimer = setInterval(() => {
        let arr = Array.from(container.children).sort((a, b) => parseInt(a.style.order) - parseInt(b.style.order));
        if (parseInt(arr[index].value) > parseInt(arr[index + 1].value)) {
            swap(arr, index, index+1);
            swapped = true;

            animate(arr[index], delay);
            animate(arr[index+1], delay);
        } else if (swapped && index >= arr.length - sorted) {
            index = 0;
            swapped = false;
            sorted++;
            return;
        } else {
            animate(arr[index], delay, "#f00");
            animate(arr[index+1], delay, "#f00");
        }
        index++;
        if (index == arr.length - 1 && !swapped) {
            clearInterval(sortTimer);
            console.log("Sorted.");
            setTimeout(() => {
                shuffle(container);
                sort(container);
            }, 1000);
            return;
        } else if (index == arr.length - 1) {
            index = 0;
            swapped = false;
            sorted++;
            return;
        }
    }, delay);
}

function swap(arr, a, b) {
    const c = arr[a].style.order;
    arr[a].style.order = arr[b].style.order;
    arr[b].style.order = c;
}

function animate(element, delay, color = "#0f0") {
    //element.style.transition = `background ${delay/3}ms`;
    element.style.background = color;
    setTimeout(() => {
        //element.style.transition = `background ${delay/2}ms`;
        element.style.background = "";
    }, delay/2);
}