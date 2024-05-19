'use client'
import styles from './InputWrapper.module.scss'

export type InputWrapperProps = {
  icon: React.ReactElement
  wrapperClassName?: string
  children: React.ReactElement
  onFocus(): void
}

const InputWrapper = ({wrapperClassName, icon, children, onFocus}: InputWrapperProps) => {
  return (
    <div className={`${styles.wrapper} ${wrapperClassName}`} onClick={() => onFocus()}>
      <div className={styles.wrapper__icon}>{icon}</div>
      {children}
    </div>
  )
}

export default InputWrapper
