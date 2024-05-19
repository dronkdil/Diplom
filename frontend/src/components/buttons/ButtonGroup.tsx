import { HtmlHTMLAttributes } from "react"
import styles from "./ButtonGroup.module.scss"

interface ButtonGroupProps extends HtmlHTMLAttributes<HTMLDivElement> {
    spaceBetween?: boolean
}

const ButtonGroup = ({className, spaceBetween, ...props}: ButtonGroupProps) => {
  return (
    <div {...props} className={`${styles.group} ${spaceBetween && styles["group__space-between"]} ${className}`} />
  )
}

export default ButtonGroup
