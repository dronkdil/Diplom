import { Radio } from "@headlessui/react"
import { CircleCheckIcon } from "lucide-react"
import { InputHTMLAttributes } from "react"
import styles from './Radio.module.scss'

interface RadioButtonProps extends InputHTMLAttributes<HTMLInputElement> {
  children: any
}

const RadioItem = ({children, value, ...props}: RadioButtonProps) => {
  return (
    <Radio
      {...props}
      value={value}
      className={styles['radio-item']}
    >
      <CircleCheckIcon className={styles['radio-item__icon']} />
      <div className={styles["radio-item__content"]}>{children}</div>
    </Radio>
  )
}

export default RadioItem
