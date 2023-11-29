// pisemka 1
{
    console.log("----- písemka 1");
    // A
    function obsahPodstavy(polomer) {
        return polomer * polomer * Math.PI;
    }
    function povrchPlasteKuzele(polomer, vyska) {
        return polomer * vyska * Math.PI;
    }
    function povrchKuzele(polomer, vyska) {
        return obsahPodstavy(polomer) + povrchPlasteKuzele(polomer, vyska);
    }

    let polomer = 3; //parseFloat(prompt("Zadejte poloměr"));
    let vyska = 7; //parseFloat(prompt("Zadejte výšku"));
    let povrch = povrchKuzele(polomer, vyska);
    console.log(povrch);
    //alert(povrch);

    // B

    function maximum(a, b) {
        return a > b ? a : b;
    }

    function maximumZPole(pole) {
        return pole.reduce((acc, cur) => cur > acc ? cur : acc, -Infinity);
    }

    function maximumZPeti(a, b, c, d, e) {
        return maximumZPole([a, b, c, d, e]);
    }
}

// pisemka 2
{
    console.log("----- písemka 2");
    // A

    let arr = new Array(300);

    for (let i = 0; i < arr.length; i++) {
        arr[i] = Math.random();
    }

    console.log("Průměr:", arr.reduce((acc, cur) => cur + acc, 0) / arr.length);
    console.log("Maximum:", arr.reduce((acc, cur) => cur > acc ? cur : acc, -Infinity));
    console.log("Minimum:", arr.reduce((acc, cur) => cur < acc ? cur : acc, Infinity));

    // B

    let asdf = [1, 7, 9, 11, 17, 2, 27];
    let nasobky = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    let p = asdf.map((v) => nasobky.map((v2) => v * v2));
    console.log(p);
}

// pisemka 3
{
    console.log("----- písemka 3");
    // A

    let arr = new Array(300);

    for (let i = 0; i < arr.length; i++) {
        arr[i] = (i + 1) * 3;
    }
    arr = arr.map((v, i) => v * 3);

    console.log(arr.reduce((acc, cur) => acc + cur, 0));

    // B

    let a = [3, 6, 9, 12, 15, 18, 21];
    let b = [7, 14, 21, 28, 35, 42, 49, 56, 63];

    console.log(a.reduce((acc, cur) => acc * cur, 1) * b.reduce((acc, cur) => acc * cur, 1));
}

// pisemka 4
{
    console.log("----- písemka 4");
    // A

    function maximum(a, b) {
        return a > b ? a : b;
    }
    function minimum(a, b) {
        return a < b ? a : b;
    }
    function maximumZeTri(a, b , c) {
        return maximum(maximum(a, b), c);
    }
    function minimumZeTri(a, b , c) {
        return minimum(minimum(a, b), c);
    }

    console.log("1, 5, -3: ", maximumZeTri(1, 5, -3));
    console.log("1, 5, -3: ", minimumZeTri(1, 5, -3));

    // B

    function obsahPodstavy(polomer) {
        return Math.PI * polomer * polomer;
    }
    function povrchPlasteValce(polomer, vyska) {
        return 2 * Math.PI * polomer * vyska;
    }
    function povrchValce(polomer, vyska) {
        return povrchPlasteValce(polomer, vyska) + obsahPodstavy(polomer) * 2;
    }

    console.log(povrchValce(3, 7));
}

// písemka 5
{
    console.log("----- písemka 5");

    let asdf = [10, 7, 4, 3, 5, 1, 2, 6, 8, 9];

    function prohod(pole, index1, index2) {
        let x = pole[index1];
        pole[index1] = pole[index2];
        pole[index2] = x
    }

    prohod(asdf, 3, 9);

    console.log(asdf);
}

// písemka 6
{
    console.log("----- písemka 6");

    let asdf = [10, 7, 4, 3, 5, 1, 2, 6, 8, 9];

    function najdi(pole, prvek) { 
        return pole.findIndex((v) => v == prvek);
    }

    console.log(najdi(asdf, 3));
}

// písemka 7
{
    console.log("----- písemka 7");

    let asdf = [3, 2, 4, 3, 5, 2, 3, 7, 3, 7];

    function pocetVyskytu(pole, prvek) {
        return pole.reduce((acc, cur) => acc + (cur == prvek ? 1 : 0), 0);
    }

    console.log(pocetVyskytu(asdf, 3));
}