module Domain

type Customer = {
    Id: int
    Name: string
    LastName: string
    CPF: string
    Age: int
    Email: string
    Phone: string
    Address: string
}

type Product = {
    Id: int
    Description: string
    Details: string
    Price: double
}

type PurchaseItem = {
    ProductId: int
    Quantity: double
    Amount: double
}

type Purchase = {
    Id: int
    CustomerId: int
    Itens: PurchaseItem list
    Amount: double
}