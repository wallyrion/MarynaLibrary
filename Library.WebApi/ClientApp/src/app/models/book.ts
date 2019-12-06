export interface Book {
    id: number;
    author: string;
    title: string;
    quantity: string;
    availableCount?: number;
}

export interface Reader {
    id: number;
    firstName: string;
    lastName: string;
    phone: string;
}

export interface Card {
    id: number;
    readerId: number;
    bookId: number;
    author: string;
    title: string;
    firstName: string;
    lastName: string;
    phone: string;
    givenDate: Date;
    returnDate: Date
}