namespace Transport

module Filters =
    [<CLIMutable>]
    type CustomerFilter = {
        Name: string
        CPF: string
        Age: int
    }

    [<CLIMutable>]
    type ProductFilter = {
        Description: string
        MaximumPrice: double
    }

module Responses =
    open Domain
    open Operators

    type CustomerResponse = {
        Id: int
        FullName: string
        CPF: string
        Age: int
        Phone: string
        Address: string
    } with
        static member
            Transform (customer : Customer) =
            {
                Id = customer.Id
                FullName = customer.Name ^ " " ^ customer.LastName
                CPF = customer.CPF
                Age = customer.Age
                Phone = customer.Phone
                Address = customer.Address
            }

    type PurchaseResponse = {
        Id: int
        Customer: CustomerResponse
        Items: PurchaseItem list
        Amount: double
    }