// TEST 1

class Dum {
    constructor(plochaDomu, plochaPozemku, pocetPokoju) {
        this.plochaDomu = plochaDomu;
        this.plochaPozemku = plochaDomu;
        this.pocetPokoju = pocetPokoju;
    }
    vypisAtributy() {
        console.log(`plochaDomu: ${this.plochaDomu}`);
        console.log(`plochaPozemku: ${this.plochaPozemku}`);
        console.log(`pocetPokoju: ${this.pocetPokoju}`);
    }
}


let domy = [];

function random(min, max) {
    return Math.floor(Math.random() * (max - min) + min);
}

for (let i = 0; i < 10; i++) {
    domy[i] = new Dum(random(10, 100), random(10, 100), random(5, 10));
}

for (dum of domy) {
    dum.vypisAtributy();
}

console.log(domy);

// TEST 2

class Vektor {
    constructor(x, y, z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    secti(vektor) {
        return new Vektor(this.x + vektor.x, this.y + vektor.y, this.z + vektor.z);
    }
}

let vektory = []

for (let i = 0; i < 100; i++) {
    vektory[i] = new Vektor(i + 1, i + 1, i + 1);
}

console.log(vektory.reduce((acc, cur) => acc = acc.secti(cur), new Vektor(0, 0, 0)));

// TEST 3

class Nepritel {
    constructor(jmeno) {
        this.jmeno = jmeno;
    }
    utok() {
        return this.jmeno + " zaútočil";
    }
}
class Skret extends Nepritel {
    utok() {
        return super.utok() + " mečem";
    }
}
class Drak extends Nepritel {
    utok() {
        return super.utok() + " ohněm";
    }
}
let skret = new Skret("Azog");
let drak = new Drak("Šmak");
console.log(skret.utok());
console.log(drak.utok());

// TEST 4

class Node {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}
class LinkedList {
    constructor() {
        this.head = null;
        this.tail = null;
    }
    add(data) {
        let node = new Node(data);
        if (this.head == null) {
            this.head = node;
            this.tail = node;
        }
        else {
            this.tail.next = node;
            this.tail = node;
        }
    }
    *[Symbol.iterator]() {
        let current = this.head;
        while (current != null) {
            yield current;
            current = current.next;
        }
    }
}

let list = new LinkedList();
for (let i = 0; i < 10; i++) {
    list.add(i);
}
for (let value of list) {
    console.log(value);
}