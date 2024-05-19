import DefaultInput, { DefaultInputProps } from '../default/DefaultInput'

interface PasswordInputProp extends Omit<DefaultInputProps, "password"> {

}

const PasswordInput = (props: PasswordInputProp) => {
  return (
    <DefaultInput {...props} type="password" />
  )
}

export default PasswordInput
