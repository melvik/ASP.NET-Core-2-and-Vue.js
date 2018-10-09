export const shoppingCartTotal = state => {
    constreducer= (accumulator, cartItem) =>
      accumulator+cartItem.price * cartItem.quantity
  
    returnstate.cart.reduce(reducer, 0)
}

export const shoppingCartItemCount = state => {
    const reducer = (accumulator, cartItem) => 
    accumulator + cartItem.quantity
    returnstate.cart.reduce(reducer, 0)
}