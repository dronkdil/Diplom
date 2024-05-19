'use client'
import { InputHTMLAttributes, createRef } from "react"
import InputWrapper from "../wrapper/InputWrapper"
import styles from './DefaultInput.module.scss'

export type DefaultInputProps = 
  InputHTMLAttributes<HTMLInputElement> & 
  {
  icon: React.ReactElement
  wrapperClassName?: string
}

const DefaultInput = ({wrapperClassName, icon,  ...props}: DefaultInputProps) => {
  const ref = createRef<HTMLInputElement>()

  return (
    <InputWrapper wrapperClassName={wrapperClassName} icon={icon} onFocus={() => ref.current?.focus()}>
      <input ref={ref} className={styles.default__input} {...props} />
    </InputWrapper>
  )
}

export default DefaultInput
