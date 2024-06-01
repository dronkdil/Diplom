import styles from '@/components/buttons/default/DefaultButton.module.scss'
import BaseLink, { BaseLinkProps } from '../base/BaseLink'

export type DefaultLinkProps = BaseLinkProps

const DefaultLink = (props: DefaultLinkProps) => {
  return (
    <BaseLink {...props} className={`${styles.default} ${props.className}`} />
  )
}

export default DefaultLink
