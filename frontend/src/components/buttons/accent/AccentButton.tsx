import BaseButton, { BaseButtonProps } from '../base/BaseButton'
import styles from './AccentButton.module.scss'

interface AccentButtonProps extends BaseButtonProps {

}

const AccentButton = (props: AccentButtonProps) => {
  return (
    <BaseButton {...props} className={styles.accent + ' ' + props.className} />
  )
}

export default AccentButton
