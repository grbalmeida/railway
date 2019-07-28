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