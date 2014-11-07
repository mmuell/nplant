using System;
using System.Linq.Expressions;
using System.Reflection;
using NPlant.Core;

namespace NPlant.MetaModel.ClassDiagraming
{
    public class AddedClassDescriptor<T> : RootClassDescriptor
    {
        public AddedClassDescriptor() : base(typeof(T))
        {
        }

        public AddedClassDescriptor<T> Named(string name)
        {
            this.Name = name;
            return this;
        }


        public AddedClassDescriptor<T> ShowInheritors()
        {
            this.RenderInheritance = true;
            return this;
        }

        public AddedClassDescriptor<T> HideInheritors()
        {
            this.RenderInheritance = false;
            return this;
        }

        public AddedClassDescriptor<T> HideMember<TMember>(Expression<Func<T, TMember>> expression)
        {
            var member = ReflectOn<T>.ForMember(expression);
            ClassDiagram.MemberVisibility[this, member.Name] = false;

            return this;
        }

        public ForMemberDescriptor<T> ForMember<TMember>(Expression<Func<T, TMember>> expression)
        {
            return new ForMemberDescriptor<T>(this, ReflectOn<T>.ForMember(expression));
        }

        public class ForMemberDescriptor<TMember>
        {
            private readonly RootClassDescriptor _descriptor;
            private readonly MemberInfo _member;

            public ForMemberDescriptor(RootClassDescriptor descriptor, MemberInfo member)
            {
                _descriptor = descriptor;
                _member = member;
            }

            public ForMemberDescriptor<TMember> Hide()
            {
                ClassDiagram.MemberVisibility[_descriptor, _member.Name] = false;
                return this;
            }
        }

        internal override IDescriptorWriter GetWriter(ClassDiagram diagram)
        {
            return new ClassWriter(diagram, this);
        }
    }
}
