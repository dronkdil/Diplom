import BaseButton, { BaseButtonProps } from '../base/BaseButton'
import styles from './DefaultButton.module.scss'

export type DefaultButtonProps = BaseButtonProps & {

}

const DefaultButton = (props: DefaultButtonProps) => {
  return (
    <BaseButton {...props} className={`${styles.default} ${props.className}`} />
  )
}

export default DefaultButton
