import styles from '@/components/buttons/accent/AccentButton.module.scss'
import BaseLink, { BaseLinkProps } from '../base/BaseLink'

export type AccentLinkProps = BaseLinkProps & {

}

const AccentLink = (props: AccentLinkProps) => {
  return (
    <BaseLink {...props} className={`${styles.accent} ${props.className}`} />
  )
}

export default AccentLink
