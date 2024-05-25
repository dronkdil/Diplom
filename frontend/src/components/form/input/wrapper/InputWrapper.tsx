'use client'
import { ResponseError } from '@/api/response.type'
import { cn } from '@/lib/utils'
import styles from './InputWrapper.module.scss'

export type InputWrapperProps = {
  icon: React.ReactElement
  wrapperClassName?: string
  children: React.ReactElement
  onFocus(): void
  error?: ResponseError
}

const InputWrapper = ({wrapperClassName, icon, children, onFocus, error}: InputWrapperProps) => {
  return (
    <div className={styles.wrapper}>
      <div className={cn(styles.wrapper__input, wrapperClassName)} onClick={() => onFocus()}>
        <div className={styles.wrapper__icon}>{icon}</div>
        {children}
      </div>
      {error && <span className={styles.wrapper__error}>{error.errorMessage}</span>}
    </div>
  )
}

export default InputWrapper
