class Vector2 {

    get X() {
        return this.#x;
    }
    get Y() {
        return this.#y;
    }

    set X(value) {
        this.#x = value;
    }
    set Y(value) {
        this.#y = value;
    }

    get size() {
        return Math.sqrt(this.#x**2 + this.#y**2);
    }

    #x;
    #y;

    constructor(x, y) {
        this.#x = x;
        this.#y = y;
    }
    add(other) {
        this.#x += other.X;
        this.#y += other.Y;
    }
}

class Vector3 extends Vector2 {

    get Z() {
        return this.#z;
    }

    set Z(value) {
        this.#z = value;
    }

    get size() {
        return Math.sqrt(super.size**2 + this.#z**2);
    }

    #z;

    constructor(x, y, z) {
        super(x, y);
        this.#z = z;
    }
    add(other) {
        super.add(other);
        this.#z += other.Z;
    }
}

let name = "newAttribute";
let bod = new Vector3(1, 2, 3);
bod[name] = 3;
console.log(bod);

// ----------------------

class Counter {

    *[Symbol.iterator]() {
        let current = this.count;
        while (current > 0) {
            yield current;
            current--;
        }
    }

    constructor(count) {
        this.count = count;
    }
}

let counter = new Counter(10);

for (const value of counter) {
    console.log(value);
}