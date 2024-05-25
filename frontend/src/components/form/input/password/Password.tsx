'use client'
import { forwardRef } from 'react'
import DefaultInput, { DefaultInputProps } from '../default/DefaultInput'

interface PasswordInputProp extends Omit<DefaultInputProps, "password"> {

}

const PasswordInput = forwardRef<HTMLInputElement, DefaultInputProps>((props: PasswordInputProp, ref) => {
  return (
    <DefaultInput {...props} ref={ref} type="password" />
  )
})

export default PasswordInput
