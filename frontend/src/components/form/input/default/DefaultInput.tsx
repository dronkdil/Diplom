'use client'
import { InputHTMLAttributes, forwardRef, useRef } from "react"
import { mergeRefs } from "react-merge-refs"
import InputWrapper, { InputWrapperProps } from "../wrapper/InputWrapper"
import styles from './DefaultInput.module.scss'

export type DefaultInputProps = 
  InputHTMLAttributes<HTMLInputElement> & 
  Omit<InputWrapperProps, "onFocus" | "children">

const DefaultInput = forwardRef<HTMLInputElement, DefaultInputProps>(({wrapperClassName, icon, error, ...props}: DefaultInputProps, ref) => {
  const inputRef = useRef<HTMLInputElement>()
  return (
    <InputWrapper wrapperClassName={wrapperClassName} icon={icon} error={error} onFocus={() => inputRef?.current?.focus()}>
      <input ref={mergeRefs([inputRef, ref])} className={styles.default__input} {...props} />
    </InputWrapper>
  )
})

export default DefaultInput
